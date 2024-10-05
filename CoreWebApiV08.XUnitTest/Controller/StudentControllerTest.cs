using AutoFixture;
using CoreWebApiV08.API.Controllers;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Repositories.Interface;
using Moq;

namespace CoreWebApiV08.XUnitTest.Controller
{
    public class StudentControllerTest
    {
        private readonly IFixture _fixture;

        private readonly Mock<IStudent> _studentMoq; 

        private readonly StudentController _studentController;


        public StudentControllerTest()
        {
            _fixture = new Fixture();
            _studentMoq = _fixture.Freeze<Mock<IStudent>>();
            _studentController = new StudentController(_studentMoq.Object, null, null);
        }
        
        [Fact]
        public void getAllStudent()
        {
            //arrange
            var moqActivity = _fixture.Create<List<StudentAdmissionModel>>();

            //_studentMoq.Setup(x => x.GetAllAsync()).Returns(moqActivity);

            //act

            //assert
        }
    }

    
}
