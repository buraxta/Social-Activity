using System.Net;
using Application.Activities.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities;

public class Edit
{
    public class Command : IRequest
    {
        public ActivityDto Activity { get; set; }
    }

    public class Handler(DataContext context, IMapper mapper, ILogger<Handler> logger)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation(
                    "Attempting to edit activity with ID: {ActivityId}",
                    request.Activity.Id
                );

                var activity = await context.Activities.FindAsync(request.Activity.Id);
                if (activity == null)
                {
                    logger.LogWarning(
                        "Activity with ID: {ActivityId} not found.",
                        request.Activity.Id
                    );
                    throw new Exception(HttpStatusCode.NotFound.ToString());
                }

                logger.LogInformation("Activity found: {@Activity}", activity);

                logger.LogDebug("Before mapping: {@Activity}", activity);
                mapper.Map(request.Activity, activity);
                logger.LogDebug("After mapping: {@Activity}", activity);
                // Save changes to the database
                var rowsAffected = await context.SaveChangesAsync();
                logger.LogInformation("Rows affected: {RowsAffected}", rowsAffected);

                logger.LogInformation(
                    "Activity with ID: {ActivityId} updated successfully.",
                    request.Activity.Id
                );
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while editing activity with ID: {ActivityId}",
                    request.Activity.Id
                );
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }
    }
}
