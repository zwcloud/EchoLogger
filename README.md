# EchoLogger

a Realtime Logger for ANY .NET core application

# Usage

TODO

# Why

Sometimes, one just want to watch a variable in real time. But under certain circumstance, we can't just use the built-in features from the IDE and the operation system.

My circumstance is in a unit test project in VS2017.

* The console won't work:  
  - [`AllocConsole`](https://docs.microsoft.com/en-us/windows/console/allocconsole): not work, (maybe the console is already occupied by the host program of the unit test)  
  - `Process.Start("cmd.exe")` and write to it's `StandardInput` stream: tried all the methods from the Internet, but it doesn't work: window not shown.

* `Debug.WriteLine` won't work:  
The xUnit/VStest framework doesn't show any text written by `Debug.WriteLine`, `Console.WriteLine` and `Trace.WriteLine`. They said we can just use a [`ITestOutputHelper`](https://xunit.github.io/docs/capturing-output.html) to capture the output. But no, we don't want to capture, we want real-time log.

So, all the methods provided by IDE and OS failed to met my realtime needs. Then I decided to write one myself, which is pretty easy.

# How

Create a TCP server listening a port, print everything it received from the port. Done.
