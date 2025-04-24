using AutoMapper;
using CleanProject.Application.Contracts.Logging;
using CleanProject.Application.Contracts.Persistence;
using CleanProject.Application.Features.LeaveType.Commands.CreateLeaveType;
using CleanProject.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using CleanProject.Application.MappingProfiles;
using CleanProject.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.UnitTests.Features.LeaveTypes.Commands
{
    public class CreateleaveTypeCommandTests
    {
        private readonly IMapper _mapper;
        private Mock<ILeaveTypeRepository> _mockRepo;

        public CreateleaveTypeCommandTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mapper, _mockRepo.Object);

            await handler.Handle(new CreateLeaveTypeCommand() { Name = "Test1", DefaultDays = 1
            }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAsync();
            leaveTypes.Count.ShouldBe(4);
        }
    }
}
