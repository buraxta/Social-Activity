using System;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;

public class Details
{
    public class Query : IRequest<Activity>
    {
        public Guid Id { get; set; }
    }

    public class Handler(DataContext context, ILogger<Handler> logger)
        : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation(
                    "Attempting to retrieve activity with ID: {ActivityId}",
                    request.Id
                );

                var activity = await context.Activities.FindAsync(request.Id);

                if (activity == null)
                {
                    logger.LogWarning("Activity with ID: {ActivityId} not found.", request.Id);
                    throw new Exception("Activity not found");
                }

                logger.LogInformation(
                    "Successfully retrieved activity with ID: {ActivityId}",
                    request.Id
                );

                return activity;
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while retrieving activity with ID: {ActivityId}",
                    request.Id
                );
                throw;
            }
        }
    }
}
