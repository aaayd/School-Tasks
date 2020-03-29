#Sieve of Eratosthenes
def get_primes(prime_amount):
    multiples = set()
    for i in range(2, prime_amount+2):
        if i not in multiples:
            yield i

            multiples.update(range(i*i, prime_amount, i))

print(sum(list(get_primes(2000000))))
