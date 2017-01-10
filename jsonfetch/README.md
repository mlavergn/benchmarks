Simple fetch of JSON data followed by a decoding.

The timing does include network latencency but I really wanted to time the entirety of the network request logic. In theory, it should average out over enough iterations. 

---

Cold start avg elapsed time:

1. 95ms go 1.8b2
1. 135ms swift 3.0.2
1. 450ms csharp	4.6.2
