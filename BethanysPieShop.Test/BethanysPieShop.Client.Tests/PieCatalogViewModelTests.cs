using BethanysPieShop.Client.Constants;
using BethanysPieShop.Client.Contracts.Services.Data;
using BethanysPieShop.Client.Contracts.Services.General;
using BethanysPieShop.Client.Models;
using BethanysPieShop.Client.ViewModels;
using Moq;

namespace BethanysPieShop.Client.Tests;

public class PieCatalogViewModelTests
{
    private PieCatalogViewModel _model;
    private Mock<ICatalogDataService> _catalogDataServiceMock;
    private Mock<INavigationService> _navigationServiceMock;

    [SetUp]
    public void Setup()
    {
        _navigationServiceMock = new Mock<INavigationService>();
        var dialogServiceMock = new Mock<IDialogService>();
        _catalogDataServiceMock = new Mock<ICatalogDataService>();
        _model = new PieCatalogViewModel(
            _navigationServiceMock.Object,
            _catalogDataServiceMock.Object,
            dialogServiceMock.Object);
    }

    [Test]
    public void Pies_ShouldNotBeNullAfterOnAppearing()
    {
        //Arrange
        _catalogDataServiceMock.Setup(service => service.GetAllPiesAsync()).ReturnsAsync(new List<Pie>
        {
            new Pie()
        });

        //Act
        _model.OnAppearing();

        //Assert
        Assert.That(_model.Pies, Is.Not.Null);
    }

    [Test]
    public void PieTappedCommand_ShouldTriggerNavigationToDetail()
    {
        //Arrange
        var tappedPie = new Pie();

        //Act
        _model.PieTappedCommand.Execute(tappedPie);

        //Assert
        _navigationServiceMock.Verify(service => service.NavigateRelativeAsync(NavigationConstants.PieDetail, tappedPie),
            Times.Once);
    }
}