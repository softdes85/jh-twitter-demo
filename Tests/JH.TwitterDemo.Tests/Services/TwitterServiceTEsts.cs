using AutoMapper;
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Data.Repositories.Interfaces;
using JH.TwitterDemo.Data.UnitOfWork;
using JH.TwitterDemo.Service.Models.Twitter;
using JH.TwitterDemo.Service.Services;
using JH.TwitterDemo.Service.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Tests.Services
{
    [TestFixture()]
    public class TwitterServiceTEsts
    {
        private ITwittRepository _twittRepository;
        private IHashTagRepository _hashTagRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private ITwittService _twittService;

        [SetUp]
        public void Setup()
        {
            _hashTagRepository = Mock.Of<IHashTagRepository>();
            _twittRepository = Mock.Of<ITwittRepository>();
            _unitOfWork = Mock.Of<IUnitOfWork>();
            _mapper = Mock.Of<IMapper>();
            this._twittService = new TwittService(_unitOfWork, _twittRepository, _hashTagRepository, _mapper);
        }

        [Test]
        public async Task When_AddTwittAsync_EntityAdded()
        {
            // Arrange
            var twittText = "Text";
            var tagText = "TagText";
            var twittINfo = new TwittInfo()
            {
                Data = new TwitInfoData()
                {
                    Text = twittText,
                    Entities = new TwitInfoEntity()
                    {
                        HashTags = new List<Service.Models.Twitter.HashTag>()
                        {
                            new Service.Models.Twitter.HashTag()
                            {
                                Tag = tagText
                            }
                        },
                        Mentions = new List<Service.Models.Twitter.Mention>(),
                    }
                }
            };

            var twit = new Twitt()
            {
                Text = twittText,
                HashTags = new List<Data.Entities.HashTag>()
                {
                    new Data.Entities.HashTag()
                    {
                        Tag = tagText
                    }
                }
            };

            Mock.Get(_mapper)
                .Setup(s => s.Map<Twitt>(It.IsAny<TwittInfo>()))
                .Returns(twit);

            Mock.Get(_twittRepository)
                .Setup(s => s.Add(It.IsAny<Twitt>()));
            Mock.Get(_hashTagRepository)
                .Setup(s => s.Add(It.IsAny<Data.Entities.HashTag>()));

            Mock.Get(_unitOfWork)
                .Setup(s => s.CommitChangesAsync());

            // Act
            await _twittService.AddTwittAsync(twittINfo);

            // Assert
            Mock.VerifyAll();
        }
    }
}