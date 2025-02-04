using System;
using System.Reflection;

namespace SampleCqrs.Api.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModelDocumentationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        string GetDocumentation(MemberInfo member);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetDocumentation(Type type);
    }
}