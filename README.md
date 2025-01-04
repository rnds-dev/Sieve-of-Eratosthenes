# Sieve of Eratosthenes

An algorithm for finding all prime numbers up to some integer n or in the range from k to n.

The essence of the algorithm is to cross out all multiples of the number i at each i iteration up to the number n:

Iteration | Multiples
:-------- | -------:
2 | 2 4 6 8 10 12..
3 | 3 9 15 21 ..
.... | ....
i | 1i 2i 3i .. n

**Result**: All remaining numbers in this range are prime

#### Thread separation
With a large amount of data (> 100,000), the algorithm occupies the main application thread, which causes the window to freeze.
To solve the problem, an asynchronous function was created using ```async```, and the function of creating tasks was used,
which are executed in a separate thread using ```await Task.Run(() => { .. })```.

This way the algorithm and the graphical interface work in different threads, which does not cause the application to freeze.


![preview](/preview.jpg)
