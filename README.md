# Jeff - A .NET Sinatra clone
After playing with System.Web.Routing I figured it would be pretty simple to build a [Sinatra](http://www.sinatrarb.com/) clone in .NET.

It's probably a horrifically naive implementation, but it seems to work.

## A basic Jeff app
Create a class that inherits from Handler and override the Routes() method. Call the Get(), Post(), Put(), and Delete() methods with a route and a function that returns a string:

<code>
public class App : Handler
{
    public override void Routes()
    {
        Get("hello", () => "Hello World");
    }
}
</code>

## What's with the name?
People tend to name these Sinatra clones after [Rat Pack](http://en.wikipedia.org/wiki/Rat_Pack) members, but I wanted to be different so called it the first name that came into my head.

## License
Copyright (c) 2010 Pete O'Grady

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
