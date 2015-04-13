using Ioana.RealEstate.Search.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Search.ElasticSearch
{
    public class EstateOfferSearchProvider
    {
        private const string INDEX_NAME = "offers";

        private readonly IElasticClient client;

        public string IndexName
        {
            get
            {
                return EstateOfferSearchProvider.INDEX_NAME;
            }
        }

        public EstateOfferSearchProvider(IElasticClient client)
	    {
            this.client = client;
	    }

        public async Task EnsureIndex()
        {
            IExistsResponse indexExistsResponse = await this.client.IndexExistsAsync(this.IndexName);
            if (!indexExistsResponse.Exists)
            {
                IIndicesOperationResponse res = await this.client.CreateIndexAsync(
                    this.IndexName,
                    r => r
                        .NumberOfShards(1)
                        .NumberOfReplicas(1)
                        .AddMapping<OfferIndexDocument>(m => m
                            .AllField(all => all.Enabled(false))
                            .Type<OfferIndexDocument>()
                            .TimestampField(t => t.Enabled().Path(d => d.DateCreated))
                            .SourceField(s => s.Enabled().Compress())
                            .Properties(p => p
                                .Number(n => n.Name(d => d.Id).Store(false).Index(NonStringIndexOption.NotAnalyzed).Type(NumberType.Integer))
                                .String(n => n.Name(d => d.OfferType).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .String(n => n.Name(d => d.City).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .String(n => n.Name(d => d.CityRegion).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .Number(n => n.Name(d => d.Price).Store(false).Index(NonStringIndexOption.NotAnalyzed).Type(NumberType.Double))
                                .String(n => n.Name(d => d.EstateType).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .String(n => n.Name(d => d.FurnishingType).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .String(n => n.Name(d => d.ConstructionStatus).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .String(n => n.Name(d => d.ConstructionType).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .Number(n => n.Name(d => d.YearOfConstruction).Store(false).Index(NonStringIndexOption.NotAnalyzed).Type(NumberType.Integer))
                                .Number(n => n.Name(d => d.Floor).Store(false).Index(NonStringIndexOption.NotAnalyzed).Type(NumberType.Integer))
                                .Boolean(n => n.Name(d => d.HasElevator).Store(false).Index(NonStringIndexOption.NotAnalyzed))
                                .String(n => n.Name(d => d.HeatingInstallations).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .Boolean(n => n.Name(d => d.HasParkingSpot).Store(false).Index(NonStringIndexOption.NotAnalyzed))
                                .Boolean(n => n.Name(d => d.HasGarage).Store(false).Index(NonStringIndexOption.NotAnalyzed))
                                .Boolean(n => n.Name(d => d.HasParkingLot).Store(false).Index(NonStringIndexOption.NotAnalyzed))
                                .String(n => n.Name(d => d.JoineryType).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .String(n => n.Name(d => d.FlooringType).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .Number(n => n.Name(d => d.Area).Store(false).Index(NonStringIndexOption.NotAnalyzed).Type(NumberType.Double))
                                .String(n => n.Name(d => d.Status).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .String(n => n.Name(d => d.PhoneNumbers).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                .Date(n => n.Name(d => d.DateCreated).Store(false).Index(NonStringIndexOption.NotAnalyzed))
                                .String(n => n.Name(d => d.Responsible).Store(false).Index(FieldIndexOption.NotAnalyzed).OmitNorms())
                                )
                        ));
            }
        }

        public async Task<OfferIndexDocument[]> Find(OfferIndexSearch searchCriteria, int skip, int take, Expression<Func<OfferIndexDocument, object>> orderBy, bool accending)
        {
            List<Func<FilterDescriptor<OfferIndexDocument>, FilterContainer>> filters = new List<Func<FilterDescriptor<OfferIndexDocument>, FilterContainer>>();
            if (!string.IsNullOrEmpty(searchCriteria.OfferType))
            {
                filters.Add(c => c.Term(d => d.OfferType, searchCriteria.OfferType));
            }

            if (!string.IsNullOrEmpty(searchCriteria.City))
            {
                filters.Add(c => c.Term(d => d.City, searchCriteria.City));
            }

            if (searchCriteria.CityRegions != null && searchCriteria.CityRegions.Length > 0)
            {
                filters.Add(c => c.Terms(d => d.CityRegion, searchCriteria.CityRegions));
            }

            if (searchCriteria.PriceFrom != null || searchCriteria.PriceTo != null)
            {
                Action<RangeFilterDescriptor<OfferIndexDocument>> priceRangeFilter;
                if (searchCriteria.PriceTo == null)
                {
                    priceRangeFilter = r => r.OnField(d => d.Price).GreaterOrEquals((double)searchCriteria.PriceFrom.Value);
                }
                else if (searchCriteria.PriceFrom == null)
                {
                    priceRangeFilter = r => r.OnField(d => d.Price).LowerOrEquals((double)searchCriteria.PriceTo.Value);
                }
                else
                {
                    priceRangeFilter = r => r.OnField(d => d.Price).GreaterOrEquals((double)searchCriteria.PriceFrom.Value).LowerOrEquals((double)searchCriteria.PriceTo.Value);
                }

                filters.Add(f => f.Range(priceRangeFilter));
            }

            if (searchCriteria.EstateTypes != null && searchCriteria.EstateTypes.Length > 0)
            {
                filters.Add(c => c.Terms(d => d.EstateType, searchCriteria.EstateTypes));
            }

            if (!string.IsNullOrEmpty(searchCriteria.FurnishingType))
            {
                filters.Add(c => c.Term(d => d.FurnishingType, searchCriteria.FurnishingType));
            }

            if (!string.IsNullOrEmpty(searchCriteria.ConstructionStatus))
            {
                filters.Add(c => c.Term(d => d.ConstructionStatus, searchCriteria.ConstructionStatus));
            }

            if (!string.IsNullOrEmpty(searchCriteria.ConstructionType))
            {
                filters.Add(c => c.Term(d => d.ConstructionType, searchCriteria.ConstructionType));
            }

            if (searchCriteria.YearOfConstruction != null)
            {
                filters.Add(c => c.Term(d => d.YearOfConstruction, searchCriteria.YearOfConstruction.Value));
            }

            if (searchCriteria.FloorFrom != null || searchCriteria.FloorTo != null)
            {
                Action<RangeFilterDescriptor<OfferIndexDocument>> floorRangeFilter;
                if (searchCriteria.FloorTo == null)
                {
                    floorRangeFilter = r => r.OnField(d => d.Floor).GreaterOrEquals(searchCriteria.FloorFrom.Value);
                }
                else if (searchCriteria.FloorFrom == null)
                {
                    floorRangeFilter = r => r.OnField(d => d.Floor).LowerOrEquals(searchCriteria.FloorTo.Value);
                }
                else
                {
                    floorRangeFilter = r => r.OnField(d => d.Floor).GreaterOrEquals(searchCriteria.FloorFrom.Value).LowerOrEquals(searchCriteria.FloorTo.Value);
                }

                filters.Add(f => f.Range(floorRangeFilter));
            }

            if (searchCriteria.HasElevator != null)
            {
                filters.Add(c => c.Term(d => d.HasElevator, searchCriteria.HasElevator.Value));
            }

            if (searchCriteria.HeatingInstallations != null && searchCriteria.HeatingInstallations.Length > 0)
            {
                filters.Add(c => c.Terms(d => d.HeatingInstallations, searchCriteria.HeatingInstallations));
            }

            if (searchCriteria.HasParkingSpot != null)
            {
                filters.Add(c => c.Term(d => d.HasParkingSpot, searchCriteria.HasParkingSpot.Value));
            }

            if (searchCriteria.HasGarage != null)
            {
                filters.Add(c => c.Term(d => d.HasGarage, searchCriteria.HasGarage.Value));
            }

            if (searchCriteria.HasParkingLot != null)
            {
                filters.Add(c => c.Term(d => d.HasParkingLot, searchCriteria.HasParkingLot.Value));
            }

            if (!string.IsNullOrEmpty(searchCriteria.JoineryType))
            {
                filters.Add(c => c.Term(d => d.JoineryType, searchCriteria.JoineryType));
            }

            if (!string.IsNullOrEmpty(searchCriteria.FlooringType))
            {
                filters.Add(c => c.Term(d => d.FlooringType, searchCriteria.FlooringType));
            }

            if (searchCriteria.AreaFrom != null || searchCriteria.AreaTo != null)
            {
                Action<RangeFilterDescriptor<OfferIndexDocument>> areaRangeFilter;
                if (searchCriteria.AreaTo == null)
                {
                    areaRangeFilter = r => r.OnField(d => d.Area).GreaterOrEquals(searchCriteria.AreaFrom.Value);
                }
                else if (searchCriteria.AreaFrom == null)
                {
                    areaRangeFilter = r => r.OnField(d => d.Area).LowerOrEquals(searchCriteria.AreaTo.Value);
                }
                else
                {
                    areaRangeFilter = r => r.OnField(d => d.Area).GreaterOrEquals(searchCriteria.AreaFrom.Value).LowerOrEquals(searchCriteria.AreaTo.Value);
                }

                filters.Add(f => f.Range(areaRangeFilter));
            }

            if (!string.IsNullOrEmpty(searchCriteria.OfferStatus))
            {
                filters.Add(c => c.Term(d => d.Status, searchCriteria.OfferStatus));
            }

            if (!string.IsNullOrEmpty(searchCriteria.PhoneNumber))
            {
                filters.Add(c => c.Term(d => d.PhoneNumbers, searchCriteria.PhoneNumber));
            }

            if (searchCriteria.OfferId != null)
            {
                filters.Add(c => c.Term(d => d.Id, searchCriteria.OfferId.Value));
            }

            if (filters.Count == 0)
            {
                return new OfferIndexDocument[0];
            }

            ISearchResponse<OfferIndexDocument> searchResult = await this.client.SearchAsync<OfferIndexDocument>(
                s => s
                    .Index(this.IndexName)
                    .Skip(skip)
                    .Take(take)
                    .Sort(sd => sd
                        .Order(accending ? SortOrder.Ascending : SortOrder.Descending)
                        .OnField(orderBy))
                    .Filter(f => f
                        .And(filters.ToArray())));

            OfferIndexDocument[] foundDocuments = searchResult.Documents.ToArray();

            return foundDocuments;
        }

        public async Task Index(OfferIndexDocument document)
        {
            IIndexResponse resp = await this.client.IndexAsync<OfferIndexDocument>(
                document,
                r => r
                    .Index(this.IndexName)
                    .Id(document.Id));
        }
    }
}
