
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Net.Http;
using TASurvey.Controllers;
using TASurvey.model.Models;
using TASurvey.Services;
using TASurvey.Services.interfaces;

namespace NUnitTTASurvey
{
    public class Tests
    {
       
        [SetUp]
        public void Setup()
        {
        }
        public Tests()
        {
                      
        }
        

        [Test]
        public void QuestionList()
        {
            var mockRepo = new Mock<ISurveysServices>();            
            var mockLogger = new Mock<ILogger<ResponsesController>>();
            var controller = new SurveysController(mockRepo.Object,mockLogger.Object);
            var result = controller.GetQuestions();
            Assert.IsNotNull(result);
            
        }

        [Test]
        public void SurveyList()
        {
            var mockRepo = new Mock<ISurveysServices>();
            var mockLogger = new Mock<ILogger<ResponsesController>>();
            var controller = new SurveysController(mockRepo.Object, mockLogger.Object);
            var result = controller.GetSurveys();
            Assert.IsNotNull(result);
            
        }

        [Test]
        public void QuestionOrderList()
        {
            var mockRepo = new Mock<ISurveysServices>();
            var mockLogger = new Mock<ILogger<ResponsesController>>();
            var controller = new SurveysController(mockRepo.Object, mockLogger.Object);
            var result = controller.GetQuestionOrders();
            Assert.IsNotNull(result);
            
        }

        [Test]
        public void QuestionCreate()
        {
            int resultStatusCode = 200;
            var mockRepo = new Mock<ISurveysServices>();
            var mockLogger = new Mock<ILogger<ResponsesController>>();
            var controller = new SurveysController(mockRepo.Object, mockLogger.Object);
            var result = controller.CreateQuestions(new Question { Text="nuevo"});
            Assert.IsNotNull(result);
            Assert.AreEqual(resultStatusCode, ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).StatusCode);
        }

        [Test]
        public void SurveyCreate()
        {
            int resultStatusCode = 200;
            var mockRepo = new Mock<ISurveysServices>();
            var mockLogger = new Mock<ILogger<ResponsesController>>();
            var controller = new SurveysController(mockRepo.Object, mockLogger.Object);
            var result = controller.CreateSurveys(new Survey { Name = "nuevo",Description="Descripción" });
            Assert.IsNotNull(result);
            Assert.AreEqual(resultStatusCode, ((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).StatusCode);
        }
        
    }
}