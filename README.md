# Benchmarks

Implementations of various common tasks under different languages with benchmarking. This is an exercise in timing specific bits of functionality in various languages. The goal is compact code, minimal overhead, and measuring how much time elapses from a single cold pass and a single warm pass.

There's the bare minimum error checking, and no tests since these are exercises in perfomance, not safety. In other words, do not cut and paste these into production bound code.

Finally, these are *microbenchmarks* and are an exercise in curiosty rather than any type of proof. Do not read too much into these or drag these into architecture planning meetings.

These benchmarks deal with non-algorithmic benchmarks, for algorithmic benchmarks, you might enjoy [The Computer Language Benchmarks Game](http://benchmarksgame.alioth.debian.org)

Warnings aside, here are the current standings from fastest to slowest:

1. C - It's been the champ (ignoring Assembly) for longer than I've been around.
1. Go - Relative Newcomer that's about ~3x slower than C, but very easy to learn
1. CSharp - Not the most modern of languages, at ~10x slower than C it's in the running
1. Python - This one I have trouble understanding but until then ~13x slower than C
1. Java - It's everywhere, at ~23x slower than C we'd expect a better showing
1. Swift - The youngest of the group, at ~45x slower than C it has room to improve

**Optimizations, improvements, code reviews, etc are always welcomed!**
