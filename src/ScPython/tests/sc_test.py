import unittest

def add(a):
    if a == "":
        return 0
    if "," in a:
        return sum(int(x) for x in a.replace("\n", ",").split(","))
    return int(a)

class TestStringCalculator(unittest.TestCase):
    def test_empty_return_zero(self):
        self.assertEqual(add(""), 0)

    def test_single_number(self):
        self.assertEqual(add("5"), 5)

    def test_two_numbers(self):
        self.assertEqual(add("1,2"), 3)

    def test_multiple_numbers(self):
        self.assertEqual(add("1,2,3,4"), 10)

    def test_numbers_with_empty_string(self):
        self.assertEqual(add("1,2"), 3)

    def test_numbers_with_newline(self):
        self.assertEqual(add("1\n2,3"), 6)

if __name__ == '__main__':
    unittest.main()