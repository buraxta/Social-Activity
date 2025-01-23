using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;

public class List
{
    public class Query : IRequest<List<Activity>> { }

    public class Handler(DataContext context, ILogger<Handler> logger)
        : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Attempting to retrieve the list of activities.");

                // Fetch the list of activities from the database
                var activities = await context.Activities.ToListAsync(cancellationToken);

                logger.LogInformation(
                    "Successfully retrieved {Count} activities.",
                    activities.Count
                );

                return activities;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while retrieving the list of activities.");
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }
    }
}
