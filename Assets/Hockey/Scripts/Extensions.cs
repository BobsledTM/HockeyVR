using System;

public static class Extensions
{
	/// <summary>
	/// Raises an event.
	/// </summary>
	public static void Raise(this EventHandler eventHandler, System.Object sender, EventArgs args)
	{
		if(eventHandler != null)
		{
			eventHandler(sender, args);
		}
	}
}
