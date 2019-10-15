using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShop.Mobile.Core.Contracts.Services.Data;
using BethanysPieShop.Mobile.Core.Contracts.Services.General;
using BethanysPieShop.Mobile.Core.Models;
using BethanysPieShop.Mobile.Core.ViewModels;
using Moq;
using NUnit.Framework;

namespace BethanysPieShop.Mobile.Tests
{
    public class PieCatalogViewModelTests
    {
        private PieCatalogViewModel _model;
        private Mock<ICatalogDataService> _catalogDataServiceMock;
        private Mock<INavigationService> _navigationServiceMock;

        [SetUp]
        public void Setup()
        {
            var connectionServiceMock = new Mock<IConnectionService>();
            _navigationServiceMock = new Mock<INavigationService>();
            var dialogServiceMock = new Mock<IDialogService>();
            _catalogDataServiceMock = new Mock<ICatalogDataService>();
            _model = new PieCatalogViewModel(connectionServiceMock.Object,
                _navigationServiceMock.Object,
                dialogServiceMock.Object,
                _catalogDataServiceMock.Object);
        }

        [Test]
        public async Task Pies_ShouldNotBeNullAfterInitializeAsync()
        {
            //Arrange
            _catalogDataServiceMock.Setup(service => service.GetAllPiesAsync()).ReturnsAsync(new List<Pie>
            {
                new Pie()
            });

            //Act
            await _model.InitializeAsync(null);

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
            _navigationServiceMock.Verify(service => service.NavigateToAsync<PieDetailViewModel>(tappedPie),
                Times.Once);
        }
    }
}