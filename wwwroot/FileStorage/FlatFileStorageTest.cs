using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwroot.FileStorage
{
    [TestFixture]
    internal class FlatFileStorageTest
    {
        public FlatFileStorageTest()
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Test");
            _container = new UnityContainer()
                .AddFlatFileStorageService();

            _fileStorage = _container.Resolve<IFileStorage>();
        }

        [Test]
        public async Task Save_ShouldReturn_SuccessResult()
        {
            // Arrange
            var filepath = @"C:\Users\abdulazeez.adams\Pictures\Logo.png";
            var fileId = Guid.NewGuid();

            // Act
            var result = await _fileStorage.Save(fileId, new FileStream(filepath, FileMode.Open));

            // Assert
            Assert.That(result.IsSuccess, Is.True);

            var getResult = await _fileStorage.Get(fileId);

            // Assert
            Assert.That(getResult.IsSuccess, Is.True);
        }

        private IUnityContainer _container;
        private IFileStorage _fileStorage;
    }
}
