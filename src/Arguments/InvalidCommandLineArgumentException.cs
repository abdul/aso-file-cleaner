using System;

namespace CommandLine.Utility
{
	/// <summary>
	/// Summary description for InvalidCommandLineArgumentException.
	/// </summary>
	public class InvalidCommandLineArgumentException : ApplicationException
	{
		public InvalidCommandLineArgumentException(string message):base(message)
		{
		}
	}
}
