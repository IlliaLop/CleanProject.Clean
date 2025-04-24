using AutoMapper;
using CleanProject.Application.Contracts.Logging;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanProject.Application.MappingProfiles;
using CleanProject.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace CleanProject.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeListQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockAppLogger;

        public GetLeaveTypeListQueryHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
