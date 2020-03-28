target = int ( input ("Triplet Test: "))

for a in range(1, round(target / 3)):
    #Taking advantage of a < b < c instead of 1,1000
    for b in range(a, round(target / 2)):
        #Taking advantage of a < b < c instead of 1,1000
        c = target - a - b
        triplet = a * a + b * b == c * c
        
        if triplet:
            print(f'Triplet: {a} {b} {c}\n' +
                  f'Sum: {a} + {b} + {c} = {a+b+c}\n' +
                  f'Product: {a} × {b} × {c} = {a*b*c}')
