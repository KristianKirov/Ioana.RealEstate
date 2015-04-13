$(function () {
    var upsertForm = $(".estate-upsert-form");
    var offerTypeId = upsertForm.find("#OfferType_Id");
    var cityDropDown = upsertForm.find("#City_Id");
    var cityRegionDropDown = upsertForm.find("#CityRegion_Id");
    var streetInput = upsertForm.find("#Street");
    var showOnMapBtn = upsertForm.find("#showOnMapBtn");

    offerTypeId.change(function () {
        var selectedValue = this.value;
        if (selectedValue == 2) {
            $("#isShortTermPanel").css("display", "");
        }
        else {
            $("#isShortTermPanel").css("display", "none");
        }
    });

    var estateUpsertFormValidator = upsertForm.data('validator');
    estateUpsertFormValidator.settings.ignore = ":hidden:not(select.chosen,.force-validation)";
    $("select.chosen").change(function (evt, params) {
        $(evt.target).valid();
    })

    ///////////////////////////////////////////////////////////////////////////

    function isFieldValid(field) {
        var nativeField = field[0];

        return $(nativeField.form).validate().check(nativeField);
    }

    $(".gmaps-editor").each(function () {
        var mapPlaceholder = $(this);
        var mapElement = mapPlaceholder.find(".gmap");
        var latEditor = mapPlaceholder.find(".lat-editor");
        var lanEditor = mapPlaceholder.find(".lon-editor");

        var lat = 43.2183532;
        var lan = 27.9089196;

        if (isFieldValid(latEditor)) {
            lat = latEditor.val();
        }

        if (isFieldValid(lanEditor)) {
            lan = lanEditor.val();
        }

        var position = new google.maps.LatLng(lat, lan);

        var map = new google.maps.Map(mapElement[0], {
            zoom: 13,
            center: position,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });

        var marker = null;

        function setInputValues(pos) {
            latEditor.val(pos.lat());
            lanEditor.val(pos.lng());
        };

        function putMarker(pos, updateInputs) {
            if (!marker) {
                marker = new google.maps.Marker({
                    position: pos,
                    map: map
                });
            }
            else {
                marker.setPosition(pos);
            }

            map.panTo(pos);

            if (updateInputs) {
                setInputValues(pos);
            }
        };

        function inputChangeHandler() {
            if (isFieldValid(latEditor) &&
                isFieldValid(lanEditor)) {
                putMarker(new google.maps.LatLng(latEditor.val(), lanEditor.val()), false);
            }
        };

        latEditor.change(inputChangeHandler);
        lanEditor.change(inputChangeHandler);

        google.maps.event.addListener(map, 'click', function (e) {
            putMarker(e.latLng, true);
        });

        inputChangeHandler();

        ////////////////////////////////////////////////

        var geocoder = new google.maps.Geocoder();

        showOnMapBtn.click(function () {
            var addressArray = [];
            if (isFieldValid(cityDropDown)) {
                var city = $("option:selected", cityDropDown).text();
                addressArray.push(city);
            }

            if (isFieldValid(cityRegionDropDown)) {
                var cityRegion = $("option:selected", cityRegionDropDown).text();
                addressArray.push(cityRegion);
            }

            if (isFieldValid(streetInput)) {
                var address = streetInput.val();
                addressArray.push(address);
            }

            if (addressArray.length) {
                geocoder.geocode({ 'address': addressArray.join(", ") }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        putMarker(results[0].geometry.location, true);
                    }
                });
            }
        });
    });

    var ownerEditor = upsertForm.find(".owner-editor");
    var newPhoneInput = ownerEditor.find(".phone-input input[type=tel]");
    var newPhoneButton = ownerEditor.find(".phone-input button[type=button]");
    var ownerIdInput = ownerEditor.find("#Owner_Id");
    var errorMessageElement = ownerEditor.find("#addPhoneError");
    var ownerEmailInput = ownerEditor.find("#Owner_Email");
    var ownerNameInput = ownerEditor.find("#Owner_Name");
    var newPhoneTemplate = ownerEditor.find(".new-phone-template").html();
    var newPhonesPlaceholder = ownerEditor.find(".phone-labels-placeholder");
    var phonesHiddenField = ownerEditor.find("#Owner_PhoneNumbers");

    function removePhoneFromButton(button) {
        var phoneLabel = button.closest(".phone-label");
        phoneLabel.remove();
    }

    function removePhone() {
        var removeButton = $(this);
        if (removeButton.hasClass("pp")) {
            ownerIdInput.val("");
            ownerEmailInput.val("");
            ownerNameInput.val("");

            newPhonesPlaceholder.find("i.pp").each(function () {
                removePhoneFromButton($(this));
            });
        }
        else {
            removePhoneFromButton(removeButton);
        }

        phonesHiddenField.valid();
    }

    function addPhones(phones, primary) {
        for (var i = 0; i < phones.length; i++) {
            var phone = phones[i];

            var phoneTemplate = $(newPhoneTemplate);
            var hiddenInput = phoneTemplate.find("input[type=hidden]");
            var phoneHolder = phoneTemplate.find(".phone-holder");
            var removePhoneButton = phoneTemplate.find(".glyphicon-remove");

            hiddenInput.val(phone);
            phoneHolder.text(phone);
            if (primary) {
                removePhoneButton.addClass("pp");
            }

            removePhoneButton.click(removePhone);

            newPhonesPlaceholder.append(phoneTemplate);
        }

        phonesHiddenField.valid();
    }

    newPhoneButton.click(function () {
        errorMessageElement.text("");
        var newPhone = newPhoneInput.val();
        if (newPhone) {
            var includeClientData = !ownerIdInput.val();
            $.get("/api/phones/validatephone",
                {
                    includeClientData: includeClientData,
                    phone: newPhone
                })
            .done(function (data, statusText, xhr) {
                newPhoneInput.val("");

                var ownerId = ownerIdInput.val();
                if (xhr.status == 200 && !ownerId) {
                    ownerIdInput.val(data.id);
                    ownerEmailInput.val(data.email);
                    ownerNameInput.val(data.names);

                    addPhones(data.phones, true);
                }
                else if (xhr.status == 204) {
                    addPhones([newPhone], false);
                }
            })
            .fail(function (xhr, statusText, error) {
                var errorMessage = null;
                if (xhr.responseText) {
                    var responseJson = JSON.parse(xhr.responseText);
                    if (responseJson.message == "Invalid phone!") {
                        errorMessage = "Невалиден телефон!";
                    }
                    else if (responseJson.message == "Phone taken!") {
                        errorMessage = "Телефонът вече съществува в системата!"
                    }
                    else if (responseJson.modelState && responseJson.modelState.phone) {
                        errorMessage = "Максималната позволена дължина е 20 символа!";
                    }
                }
                errorMessage = errorMessage || "Възникна неочаквана грешка!";

                errorMessageElement.text(errorMessage);
            });
        }
    });

    var alreadyCalledInput = upsertForm.find("#Called_AlreadyCalled");
    alreadyCalledInput.change(function () {
        var alreadyCalled = $(this).is(":checked");
        if (alreadyCalled) {
            $(".is-called-slave").show();
        }
        else {
            $(".is-called-slave").hide();
        }
    });
});