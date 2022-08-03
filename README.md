# Now And Next

_Inspired by [now_and_next](https://github.com/sweavo/now_and_next) by Steve
Carter. Some of this description is from his version._

# Intro

Put time in your visual field so that you are not perpetually late for meetings.

![Screenshot](doc/img/screenshot.png)

# Purpose

You can go read the original purpose statement
[here](https://github.com/sweavo/now_and_next#instructions).

The user story from the original is:

> **As a** person with time-blindness who has to mix appointments and other
> work,<br>
> **I want to** be constantly reminded how long it is until my next appointment
> <br>
> **so that** I can manage my work and show up to meetings on time.

# Why Reimplement It In C♯?

I rewrote it in C♯ and .NET to improve the handling of integration with Outlook
(C♯ is better than Python at interacting with COM) and so it was more easily
usable for non-engineers (no need to setup Python).

It also just seemed fun to do!

# Installation

You can download releases from the
[Releases](https://github.com/JMAlego/NowAndNext/releases) section of this
repository.

Releases come in three flavours:

- Standalone x86
- Standalone x64
- Framework Dependant / Portable

To use the Framework Dependant version you'll need to have [.NET 6 Desktop
Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime)
installed.

Currently only Windows builds are provided as the application relies on the COM
interface to Outlook.

Once you've downloaded the release you can put it where ever you want and run
it from there. There's currently no installer so you'll have to work out where
you want it and make your own shortcuts.

# Building

You can build this project using Visual Studio 2022 or `msbuild`, but not
`dotnet`. COM interaction isn't well supported in the `dotnet` CLI builder
hence the dependency on a more Visual Studio adjacent build tool.


# License

This project is licensed under the BSD 3-Clause License.

The original project, [now_and_next](https://github.com/sweavo/now_and_next) by
Steve Carter is licensed under the MIT Licnese.

