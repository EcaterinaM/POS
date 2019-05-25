using System;
using System.Linq.Expressions;
using BuildingVitals.DataAccessContracts.Entities;

namespace BuildingVitals.DataAccessContracts.Helpers
{
    /// <summary>
    /// The SensorDataExtentions.
    /// </summary>
    public static class MetricHelper
    {
        /// <summary>
        /// Queries the property lambda.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns></returns>
        public static Expression<Func<Metric, string>> GetPropertyExpression(string propertyName)
        {
            var sensorData = Expression.Parameter(typeof(Metric), "sd");
            var queryPropertyExpression = Expression.PropertyOrField(sensorData, propertyName);
            return Expression.Lambda<Func<Metric, string>>(queryPropertyExpression, sensorData);
        }

        /// <summary>
        /// Nots the null query property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static Expression<Func<Metric, bool>> GetNotNullPropertyExpression(string propertyName)
        {
            var sensorData = Expression.Parameter(typeof(Metric), "sd");
            var queryPropertyExpression = Expression.PropertyOrField(sensorData, propertyName);
            var nullConstant = Expression.Constant(null);
            var notNullExpression = Expression.NotEqual(queryPropertyExpression, nullConstant);
            return Expression.Lambda<Func<Metric, bool>>(notNullExpression, sensorData);
        }
    }
}
