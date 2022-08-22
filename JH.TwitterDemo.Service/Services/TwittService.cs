using AutoMapper;
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Data.Repositories.Interfaces;
using JH.TwitterDemo.Data.UnitOfWork;
using JH.TwitterDemo.Service.Models.Twitter;
using JH.TwitterDemo.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services
{
    public class TwittService : ITwittService
    {
        private readonly ITwittRepository _twittRepository;
        private readonly IHashTagRepository _hashTagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TwittService(IUnitOfWork unitOfWork, ITwittRepository twittRepository, IHashTagRepository hashTagRepository, IMapper mapper)
        {
            this._twittRepository = twittRepository;
            this._hashTagRepository = hashTagRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task AddTwittAsync(TwittInfo twitt)
        {
            var twittEntity = this._mapper.Map<Twitt>(twitt);
            this._twittRepository.Add(twittEntity);

            foreach (var hash in twittEntity.HashTags)
                this._hashTagRepository.Add(hash);

            await this._unitOfWork.CommitChangesAsync();
        }
    }
}