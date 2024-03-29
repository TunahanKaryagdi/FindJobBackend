﻿using FindJob.Application.Repositories;
using FindJob.Application.Utilities.Results;
using MediatR;

namespace FindJob.Application.Features.Skill.Commands
{
    public class CreateSkillCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public int Experience { get; set; }

        public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, IResult>
        {
            ISkillWriteRepository _skillWriteRepository;

            public CreateSkillCommandHandler(ISkillWriteRepository skillWriteRepository)
            {
                _skillWriteRepository = skillWriteRepository;
            }

            public async Task<IResult> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
            {
                await _skillWriteRepository.AddAsync(new Domain.Entities.Skill { Name = request.Name, UserId = Guid.Parse(request.UserId), Experience = request.Experience });
                await _skillWriteRepository.SaveAsync();
                return new SuccessResult("");
            }
        }

    }
}
