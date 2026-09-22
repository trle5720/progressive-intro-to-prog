package calculator

import (
	"strings"
	"testing"
)

func TestCalculatorAdd(t *testing.T) {
	tests := []struct {
		name     string
		input    string
		expected int
	}{
		{name: "empty string", input: "", expected: 0},
		{name: "single number", input: "42", expected: 42},
		{name: "two comma separated numbers", input: "1,2", expected: 3},
		{name: "arbitrary number of values", input: "1,2,3,4,5,6,7,8,9", expected: 45},
		{name: "mixed comma and newline delimiters", input: "1\n2,3", expected: 6},
		{name: "custom delimiter", input: "//#\n1#2#3", expected: 6},
		{name: "custom delimiter with standard delimiters", input: "//#\n1#2,3\n1", expected: 7},
		{name: "numbers over 1000 are ignored", input: "2,3,9876", expected: 5},
		{name: "multi-character custom delimiter", input: "//[***]\n1***2", expected: 3},
		{name: "multiple custom delimiters", input: "//[***, #, !]\n1***2#3\n1!2", expected: 9},
	}

	calculator := Calculator{}

	for _, test := range tests {
		t.Run(test.name, func(t *testing.T) {
			if actual := calculator.Add(test.input); actual != test.expected {
				t.Fatalf("Add(%q) = %d, want %d", test.input, actual, test.expected)
			}
		})
	}
}

func TestCalculatorAddRejectsAllNegativeNumbers(t *testing.T) {
	calculator := Calculator{}

	defer func() {
		recovered := recover()
		if recovered == nil {
			t.Fatal("Add did not panic for negative numbers")
		}
		message := recovered.(string)
		for _, negative := range []string{"-2", "-5", "-9"} {
			if !strings.Contains(message, negative) {
				t.Errorf("panic message %q does not contain %q", message, negative)
			}
		}
	}()

	calculator.Add("1,-2,3,-5,-9")
}
