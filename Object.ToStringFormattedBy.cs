// A part of the C# Language Syntactic Sugar suite.

using System;
using System.Collections;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class ObjectToStringFormattedBy
  {
    /// <summary>
    /// Inserts the source object's string representation into the specified
    /// format's format item index 0. Objects passed in after the format string
    /// are additionally inserted into following format items.
    /// A parameter supplies culture-specific formatting information.
    /// </summary>
    /// <param name="arg0">The first object to format.</param>
    /// <param name="provider">
    /// <inheritdoc cref="String.Format(IFormatProvider, string, object[])"
    /// path="/param[@name='provider']"/></param>
    /// <param name="format">
    /// <inheritdoc cref="String.Format(IFormatProvider, string, object[])"
    /// path="/param[@name='format']"/></param>
    /// <param name="args">An object array that contains zero or more objects to
    /// format after the source object.</param>
    /// <returns>A copy of <paramref name="format"/> in which the format items
    /// have been replaced by the string representation of the corresponding
    /// objects starting with the source object and then by objects in
    /// <paramref name="args"/>.</returns>
    public static string ToStringFormattedBy(this object arg0,
      IFormatProvider provider,
      string format,
      params object[] args)
    {
      if (args.Length == 0) return String.Format(provider, format, arg0);
      var combinedArgs = new object[args.Length + 1];
      combinedArgs[0] = arg0;
      for (int i = 0; i < args.Length; ++i) combinedArgs[i + 1] = args[i];
      return String.Format(provider, format, combinedArgs);
    }

    /// <summary>
    /// Inserts the source object's string representation into the specified
    /// format's format item index 0. Objects passed in after the format string
    /// are additionally inserted into following format items.
    /// </summary>
    /// <param name="arg0">
    /// <inheritdoc cref="ToStringFormattedBy(object, IFormatProvider, string, object[])"
    /// path="/param[@name='arg0']"/></param>
    /// <param name="format">
    /// <inheritdoc cref="String.Format(IFormatProvider, string, object[])"
    /// path="/param[@name='format']"/></param>
    /// <param name="args">
    /// <inheritdoc cref="ToStringFormattedBy(object, IFormatProvider, string, object[])"
    /// path="/param[@name='args']"/></param>
    /// <returns>
    /// <inheritdoc cref="ToStringFormattedBy(object, IFormatProvider, string, object[])"
    /// path="/returns"/></returns>
    public static string ToStringFormattedBy(this object arg0,
      string format,
      params object[] args)
    {
      if (args.Length == 0) return String.Format(format, arg0);
      var combinedArgs = new object[args.Length + 1];
      combinedArgs[0] = arg0;
      for (int i = 0; i < args.Length; ++i) combinedArgs[i + 1] = args[i];
      return String.Format(format, combinedArgs);
    }

    /// <summary>
    /// Inserts the source collection's object string representations into the
    /// specified format's format items starting at index 0, then additionally
    /// does the same to objects passed in after the format string starting
    /// after the source array.
    /// A parameter supplies culture-specific formatting information.
    /// </summary>
    /// <param name="sourceArgs">The first objects to format.</param>
    /// <param name="provider">
    /// <inheritdoc cref="String.Format(IFormatProvider, string, object[])"
    /// path="/param[@name='provider']"/></param>
    /// <param name="format">
    /// <inheritdoc cref="String.Format(IFormatProvider, string, object[])"
    /// path="/param[@name='format']"/></param>
    /// <param name="args">An object array that contains zero or more objects to
    /// format after the source's objects.</param>
    /// <returns>A copy of <paramref name="format"/> in which the format items
    /// have been replaced by the string representation of the corresponding
    /// objects starting with the source's objects and then by objects in
    /// <paramref name="args"/>.</returns>
    public static string ToStringFormattedBy(
      this ICollection<object> sourceArgs,
      IFormatProvider provider,
      string format,
      params object[] args)
    {
      if (args.Length == 0)
      {
        var sourceAsArray = sourceArgs as object[];
        if (sourceAsArray != null)
          return String.Format(provider, format, sourceAsArray);
      }
      var combinedArgs = new object[args.Length + sourceArgs.Count];
      int sourceIdx = 0;
      foreach (var arg in sourceArgs)
      { combinedArgs[sourceIdx] = arg; ++sourceIdx; }
      for (int i = 0; i < args.Length; ++i)
        combinedArgs[i + sourceArgs.Count] = args[i];
      return String.Format(provider, format, combinedArgs);
    }

    /// <inheritdoc cref="ToStringFormattedBy(ICollection{object}, IFormatProvider, string, object[])"/>
    public static string ToStringFormattedBy(this ICollection sourceArgs,
      IFormatProvider provider,
      string format,
      params object[] args)
    {
      if (args.Length == 0)
      {
        var sourceAsArray = sourceArgs as object[];
        if (sourceAsArray != null)
          return String.Format(provider, format, sourceAsArray);
      }
      var combinedArgs = new object[args.Length + sourceArgs.Count];
      int sourceIdx = 0;
      foreach (var arg in sourceArgs)
      { combinedArgs[sourceIdx] = arg; ++sourceIdx; }
      for (int i = 0; i < args.Length; ++i)
        combinedArgs[i + sourceArgs.Count] = args[i];
      return String.Format(provider, format, combinedArgs);
    }

    /// <summary>
    /// Inserts the source collection's object string representations into the
    /// specified format's format items starting at index 0, then additionally
    /// does the same to objects passed in after the format string starting
    /// after the source array.
    /// </summary>
    /// <param name="sourceArgs">
    /// <inheritdoc cref="ToStringFormattedBy(ICollection{object}, IFormatProvider, string, object[])"
    /// path="/param[@name='sourceArgs']"/></param>
    /// <param name="format">
    /// <inheritdoc cref="String.Format(IFormatProvider, string, object[])"
    /// path="/param[@name='format']"/></param>
    /// <param name="args">
    /// <inheritdoc cref="ToStringFormattedBy(ICollection{object}, IFormatProvider, string, object[])"
    /// path="/param[@name='args']"/></param>
    /// <returns>
    /// <inheritdoc cref="ToStringFormattedBy(ICollection{object}, IFormatProvider, string, object[])"
    /// path="/returns"/></returns>
    public static string ToStringFormattedBy(
      this ICollection<object> sourceArgs,
      string format,
      params object[] args)
    {
      if (args.Length == 0)
      {
        var sourceAsArray = sourceArgs as object[];
        if (sourceAsArray != null)
          return String.Format(format, sourceAsArray);
      }
      var combinedArgs = new object[args.Length + sourceArgs.Count];
      int sourceIdx = 0;
      foreach (var arg in sourceArgs)
      { combinedArgs[sourceIdx] = arg; ++sourceIdx; }
      for (int i = 0; i < args.Length; ++i)
        combinedArgs[i + sourceArgs.Count] = args[i];
      return String.Format(format, combinedArgs);
    }

    /// <inheritdoc cref="ToStringFormattedBy(ICollection, IFormatProvider, string, object[])"/>
    public static string ToStringFormattedBy(this ICollection sourceArgs,
      string format,
      params object[] args)
    {
      if (args.Length == 0)
      {
        var sourceAsArray = sourceArgs as object[];
        if (sourceAsArray != null)
          return String.Format(format, sourceAsArray);
      }
      var combinedArgs = new object[args.Length + sourceArgs.Count];
      int sourceIdx = 0;
      foreach (var arg in sourceArgs)
      { combinedArgs[sourceIdx] = arg; ++sourceIdx; }
      for (int i = 0; i < args.Length; ++i)
        combinedArgs[i + sourceArgs.Count] = args[i];
      return String.Format(format, combinedArgs);
    }
  }
}