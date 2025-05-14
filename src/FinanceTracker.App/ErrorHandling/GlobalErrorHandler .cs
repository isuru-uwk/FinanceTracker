using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace FinanceTracker.App.ErrorHandling
{
    /// <summary>
    /// Global error handler component for Blazor application
    /// </summary>
    public class GlobalErrorHandler : ErrorBoundary
    {
        [Inject] private ILogger<GlobalErrorHandler> Logger { get; set; } = default!;
        [Inject] private ISnackbar Snackbar { get; set; } = default!;

        /// <summary>
        /// The custom error UI to display when an error occurs
        /// </summary>
        [Parameter] public RenderFragment? ErrorContent { get; set; }

        /// <summary>
        /// Whether to automatically redirect to an error page on exception
        /// </summary>
        [Parameter] public bool RedirectToErrorPage { get; set; } = false;

        /// <summary>
        /// The path to redirect to when an error occurs (if RedirectToErrorPage is true)
        /// </summary>
        [Parameter] public string ErrorPagePath { get; set; } = "/error";

        protected override Task OnErrorAsync(Exception exception)
        {
            Logger.LogError(exception, "Unhandled exception in Blazor UI: {Message}", exception.Message);
            Snackbar.Add(GetUserFriendlyErrorMessage(exception),Severity.Error);

            return base.OnErrorAsync(exception);
        }

        private static string GetUserFriendlyErrorMessage(Exception exception)
        {
            // Customize error messages based on exception type
            return exception switch
            {
                KeyNotFoundException => "The requested item was not found.",
                HttpRequestException httpEx when httpEx.StatusCode == System.Net.HttpStatusCode.Unauthorized =>
                    "You are not authorized to perform this action. Please log in and try again.",
                HttpRequestException httpEx when httpEx.StatusCode == System.Net.HttpStatusCode.Forbidden =>
                    "You don't have permission to access this resource.",
                HttpRequestException httpEx when httpEx.StatusCode == System.Net.HttpStatusCode.NotFound =>
                    "The requested resource was not found.",
                InvalidOperationException => "The operation couldn't be completed. Please try again.",
                _ => "An unexpected error occurred. If the problem persists, please contact support."
            };
        }
    }
}