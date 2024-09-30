namespace RealEstateApi.Repositories.StatisticsRepositories;

public interface IStatisticsRepository
{
    int CategoryCount();
    int ActiveCategoryCount();
    int InactiveCategoryCount();
    int PropertyCount();
    int ApartmentCount();
    string EmployeeWithMostProperties();
    string CategoryWithMostProperties();
    decimal AveragePropertyByRentPrice();
    decimal AveragePropertyBySalePrice();
    string CityNameByMaxProductCount();
    int DifferentCityCount();
    decimal LastPropertyPrice();
    string NewestBuildingYear();
    string OldestBuildingYear();
    int AverageRoomCount();
    int ActiveEmployeeCount();
}