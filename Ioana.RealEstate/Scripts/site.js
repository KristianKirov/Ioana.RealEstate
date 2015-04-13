$(".chosen").chosen({
    width: "100%",
    no_results_text: "Няма съвпадения"
});

$("#toggle-estate-search").click(function (e) {
    e.preventDefault();
    $(".estate-search-placeholder").slideToggle();
});

var phoneNumbersValidatorNamee = "phonenumbersrequired";
$.validator.addMethod(phoneNumbersValidatorNamee, function (value, element, params) {
    var addedPhonesCount = $(element).siblings(".phone-label").length;

    return !!addedPhonesCount;
});

$.validator.unobtrusive.adapters.add(phoneNumbersValidatorNamee, function (options) {
    options.messages[phoneNumbersValidatorNamee] = options.message;
    options.rules[phoneNumbersValidatorNamee] = options.params;
});

$(function () {
    function createThumbnail(file, callback) {
        var fileReader;
        fileReader = new FileReader;
        fileReader.onload = (function(func) {
            return function() {
                if (file.type === "image/svg+xml") {
                    return;
                }
                return func(file, fileReader.result, callback);
            };
        })(createThumbnailFromUrl);

        return fileReader.readAsDataURL(file);
    };

    function createThumbnailFromUrl(file, imageUrl, callback) {
        var img;
        img = document.createElement("img");
        img.onload = (function() {
            return function() {
                var canvas, ctx, resizeInfo, thumbnail;
                //file.width = img.width;
                //file.height = img.height;
                resizeInfo = { trgWidth: 150, trgHeight: 150 };
                var wRatio = img.width / resizeInfo.trgWidth;
                var hRation = img.height / resizeInfo.trgHeight;

                var ratio = wRatio < hRation ? hRation : wRatio;
                var w = img.width / ratio;
                var h = img.height / ratio;
                
                canvas = document.createElement("canvas");
                ctx = canvas.getContext("2d");
                canvas.width = w;
                canvas.height = h;
                ctx.drawImage(img, 0, 0, w, h);
                thumbnail = canvas.toDataURL("image/png");
                if (callback != null) {
                    return callback(thumbnail);
                }
            };
        })();

        return img.src = imageUrl;
    };

    function createUploaderFromTemplate(templateElement) {
        var templateText = templateElement.html();

        var fileUploader = $(templateText);

        var fileInput = fileUploader.find("input[type=file]");
        var previewImage = fileUploader.find(".preview-image");

        fileInput.filestyle({
            buttonText: fileInput.data("buttonText")
        });

        fileInput.change(function () {
            if (FileReader) {
                var fileInputNative = fileInput.get(0);
                var files = fileInputNative.files ? fileInputNative.files : fileInputNative.currentTarget.files;
                if (files && files[0]) {
                    var file = files[0];
                    var imageType = /image.*/;
                    if (file.type.match(imageType)) {
                        createThumbnail(file, function (thumbnail) {
                            previewImage.css("background-image", "url(" + thumbnail + ")");
                        });
                    }
                }
                else {
                    previewImage.css("background-image", "");
                }
            }
        });

        fileUploader.insertBefore(templateElement);
    }

    $(".file-upload-template").each(function () {
        (function (uploadTemplate) {
            createUploaderFromTemplate(uploadTemplate);
        })($(this));
    });

    $(".render-template").click(function (e) {
        e.preventDefault();

        var el = $(this);
        var templateSelector = el.data("template");
        createUploaderFromTemplate($(templateSelector));
    });
});

//$(function () {

//    function attachFileUploadEvents(fileUploader) {
//        var fileInput = fileUploader.find("input[type=file]");
//        var previewImage = fileUploader.find(".preview-image");

//        fileInput.filestyle({
//            buttonText: fileInput.data("fileInput")
//        });

//        fileInput.change(function () {
//            if (FileReader) {
//                var fileInputNative = fileInput.get(0);
//                var files = fileInputNative.files ? fileInputNative.files : fileInputNative.currentTarget.files;
//                if (files && files[0]) {
//                    var file = files[0];
//                    var imageType = /image.*/;
//                    if (file.type.match(imageType)) {
//                        var reader = new FileReader();
//                        reader.onload = (function (aImg) {
//                            return function (e) {
//                                aImg.attr("src", e.target.result);
//                            };
//                        })(previewImage);
//                        reader.readAsDataURL(file);
//                    }
//                }
//            }

//            if (true) {
//                var newFileUploader = fileUploader.clone();
//                newFileUploader.insertAfter(fileUploader);
//            }
//        });
//    }

//    $(".file-uploader").each(function () {
//        var fileUploader = $(this);
//        attachFileUploadEvents(fileUploader);
//    });
//});