using AutoMapper;
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Service.Mapper;
using JH.TwitterDemo.Service.Models.Twitter;
using NUnit.Framework;
using System.Collections.Generic;

namespace JH.TwitterDemo.Tests.AutoMapper
{
    [TestFixture()]
    public class TwittProfileTests
    {
        private MapperConfiguration config;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            config = new MapperConfiguration(cfg => cfg.AddProfile<TwittProfile>());
            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();
        }

        [Test]
        public void Test_TwittInfoToTwitt_Mapper()
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

            // Act
            var actual = mapper.Map<Twitt>(twittINfo);

            // Arrange
            Assert.AreEqual(actual.Text, twittINfo.Data.Text);
        }
    }
}