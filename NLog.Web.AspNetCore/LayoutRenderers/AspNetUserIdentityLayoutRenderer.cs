using System.Text;
#if !NETSTANDARD_1plus
using System.Web;
#else
#endif
using NLog.LayoutRenderers;

namespace NLog.Web.LayoutRenderers
{
    /// <summary>
    /// ASP.NET User variable.
    /// </summary>
    [LayoutRenderer("aspnet-user-identity")]
    public class AspNetUserIdentityLayoutRenderer : AspNetLayoutRendererBase
    {
        /// <summary>
        /// Renders the specified ASP.NET User.Identity.Name variable and appends it to the specified <see cref="StringBuilder" />.
        /// </summary>
        /// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
        /// <param name="logEvent">Logging event.</param>
        protected override void DoAppend(StringBuilder builder, LogEventInfo logEvent)
        {
            var context = HttpContextAccessor.HttpContext;

            if (context.User?.Identity == null)
            {
                return;
            }

            builder.Append(context.User.Identity.Name);
        }
    }
}