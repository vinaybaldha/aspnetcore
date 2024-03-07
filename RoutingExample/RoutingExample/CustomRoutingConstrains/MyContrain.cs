
using System.Text.RegularExpressions;

namespace RoutingExample.CustomRoutingConstrains
{
    public class MyContrain : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(!values.ContainsKey(routeKey))
            {
                return false;
            }

            string? key = Convert.ToString(values[routeKey]);
            Regex regex = new Regex("^(apr|may|jun)$");

            if(regex.IsMatch(key))
            {
                return true;
            }
            return false;

        }
    }
}
