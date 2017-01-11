Simple fetch of JSON data followed by a decoding.

The timing does include network latencency but I wanted to include the entirety of the network request logic. In theory, it should average out over enough iterations. 

---

Cold start avg elapsed time:

1. 95ms go 1.8b2
1. 120ms python 2.7.10
1. 135ms swift 3.0.2
1. 260ms csharp	4.6.2
1. 465ms java	1.8.0
