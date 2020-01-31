using BookStore.Application.Controllers;
using BookStore.Domain.Entities;
using BookStore.Infra.Context;
using BookStore.Infra.Repository;
using BookStore.Service.Service;
using BookStore.Test.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Test
{
    [TestClass]
    public class AuthorTests
    {
        private static MyContext _myContext;
        private static AuthorRepository _repository;
        private static AuthorService _service;
        private static AuthorController _controller;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ConnectionString.setDev();
            _myContext = new ContextFactory().CreateDbContext(new string[] { });
            _repository = new AuthorRepository(_myContext);
            _service = new AuthorService(_repository);
            _controller = new AuthorController(_service);
        }

        [TestMethod]
        public async Task ShouldGetAnEmptyAuthorsList()
        {
            var response = (ObjectResult)await _controller.GetAll();

            var value = response.Value.GetType()
                .GetProperty("Count")
                .GetValue(response.Value);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public  async Task ShouldPostAuthors()
        {
            Author author = new Author
            {
                Name = "Comedy"
            };

            ObjectResult responsePost = (ObjectResult)await _controller.Post(author);
            Author respPost = (Author)responsePost.Value;

            ObjectResult responseGet = (ObjectResult)await _controller.Get(respPost.Id);
            Author respGet = (Author)responsePost.Value;

            var responseGetAll = (ObjectResult)await _controller.GetAll();
            var respGetAll = responseGetAll.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll.Value);


            Assert.AreEqual(200, (int)responsePost.StatusCode);
            Assert.AreEqual(200, (int)responseGet.StatusCode);
            Assert.AreEqual(respGet.Id, respPost.Id);
            Assert.AreEqual(1, respGetAll);

        }

        [TestMethod]
        public  async Task ShouldPutAuthorById()
        {
            Author author = new Author
            {
                Name = "Comedy"
            };

            ObjectResult responsePost = (ObjectResult)await _controller.Post(author);
            Author respPost = (Author)responsePost.Value;

            author.Name = "Action";

            ObjectResult responsePut = (ObjectResult)await _controller.Put(author, respPost.Id);
            Author respPut = (Author)responsePost.Value;

            Assert.AreEqual(200, (int)responsePost.StatusCode);
            Assert.AreEqual(200, (int)responsePut.StatusCode);
            Assert.AreEqual(respPut.Name, author.Name);
        }

        [TestMethod]
        public  async Task ShouldDeleteAuthorById()
        {
            Author author = new Author
            {
                Name = "Comedy"
            };

            ObjectResult responsePost = (ObjectResult)await _controller.Post(author);
            Author respPost = (Author)responsePost.Value;

            ObjectResult responseDelete = (ObjectResult)await _controller.Delete(respPost.Id);
            ResponseEntity respDelete = (ResponseEntity)responseDelete.Value;

            var responseGet = await _controller.Get(respPost.Id);

            Assert.AreEqual(200, (int)responsePost.StatusCode);
            Assert.AreEqual(200, respDelete.Status);
        }

        [TestMethod]
        public async Task ShouldFindAllAuthorAndDelete()
        {

            var responseGetAll = (ObjectResult)await _controller.GetAll();
            var respGetAll = (IEnumerable<Author>)responseGetAll.Value;

            foreach (Author author in respGetAll)
            {
                ObjectResult responseDelete = (ObjectResult)await _controller.Delete(author.Id);
                ResponseEntity respDelete = (ResponseEntity)responseDelete.Value;
                Assert.AreEqual(200, respDelete.Status);
            }

            var responseGetAll2 = (ObjectResult)await _controller.GetAll();
            var valueGetAll = responseGetAll2.Value.GetType()
                .GetProperty("Count")
                .GetValue(responseGetAll2.Value);
            Assert.AreEqual(0, valueGetAll);
        }

    }
}
