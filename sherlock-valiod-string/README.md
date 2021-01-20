# Sherlock and the Valid String


## Thoughts

- Group letters
- Create a dictionary with the letter count as the key, and the value will be the number of letters with the same quantity in the string.

        input: `ABBCC`

        groups: { A, B C }

        dic
        {
            { 1: 2 },
            { 2, 1 }
        }

- Verify how many unique frequencies we have.

    Example 1:

        input: aabbccddeefghi

        groups: { a, b, c, d, e, f, g, h, i }

        dic
        {
            { 1: 4 },
            { 2, 5 }
        }


    Example 2:

        input: abcdefghhgfedecba

        groups: { a, b, c, d, e, f, g, h }

        dic
        {
            { 2: 7 },
            { 1: 1 }
        }


        abcdefghhgfedecba

        aabbccddeeeffgghh

        lastChar =          '' | a | a | b | b | c | c | d | d | e | e | e
        lastCharCount =     0  | 1 | 2 | 1 | 2 | 1 | 2 | 
        lastDiffCharCount = 0  | 0 | 0 | 2 | 2 | 2 | 2 | 
        frequencies =       0  | 1 | 1 | 1 | 1 | 1 | 1 | 
        biggerFreqCount     0  | 0 | 0 | 2 | 2 | 2 | 2 |
        lowerFreqCount      0  | 0 | 0 | 2 | 2 | 2 | 2 |

        a
        a
        b
        b
        c
        c
        d
        d
