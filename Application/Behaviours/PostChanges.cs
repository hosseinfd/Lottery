﻿using Application.BuildingBlocks.CQRS.Commands;
using Domain.RepoInterfaces;
using MediatR.Pipeline;

namespace Application.Behaviours;

public class PostChanges<Treq,Tres> : IRequestPostProcessor<ICommand,Tres>
{
    private readonly IUnitOfWork _unitOfWork;

    public PostChanges(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Process(ICommand request, Tres response, CancellationToken cancellationToken)
    {
        await _unitOfWork.SaveChangesAsync();
    }
}