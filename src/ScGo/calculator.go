package calculator

import (
	"fmt"
	"sort"
	"strconv"
	"strings"
)

type Calculator struct{}

func (Calculator) Add(numbers string) int {
	if numbers == "" {
		return 0
	}

	delimiters, numbers := parseInput(numbers)
	values := splitNumbers(numbers, delimiters)
	negativeNumbers := make([]string, 0)
	total := 0

	for _, value := range values {
		number, err := strconv.Atoi(value)
		if err != nil {
			continue
		}
		if number < 0 {
			negativeNumbers = append(negativeNumbers, value)
			continue
		}
		if number <= 1000 {
			total += number
		}
	}

	if len(negativeNumbers) > 0 {
		panic(fmt.Sprintf("negative numbers are not allowed: %s", strings.Join(negativeNumbers, ", ")))
	}

	return total
}

func parseInput(numbers string) ([]string, string) {
	const prefix = "//"
	delimiters := []string{",", "\n"}

	if !strings.HasPrefix(numbers, prefix) {
		return delimiters, numbers
	}

	lineBreak := strings.IndexByte(numbers, '\n')
	if lineBreak < 0 {
		return delimiters, numbers
	}

	header := numbers[len(prefix):lineBreak]
	if strings.Contains(header, "[") {
		for start := 0; start < len(header); {
			open := strings.IndexByte(header[start:], '[')
			if open < 0 {
				break
			}
			open += start
			close := strings.IndexByte(header[open+1:], ']')
			if close < 0 {
				break
			}
			close += open + 1
			for _, delimiter := range strings.Split(header[open+1:close], ",") {
				delimiters = append(delimiters, strings.TrimSpace(delimiter))
			}
			start = close + 1
		}
	} else {
		delimiters = append(delimiters, header)
	}

	return delimiters, numbers[lineBreak+1:]
}

func splitNumbers(numbers string, delimiters []string) []string {
	orderedDelimiters := append([]string(nil), delimiters...)
	sort.SliceStable(orderedDelimiters, func(left, right int) bool {
		return len(orderedDelimiters[left]) > len(orderedDelimiters[right])
	})

	if len(orderedDelimiters) == 0 {
		return []string{numbers}
	}
	replacements := make([]string, 0, len(orderedDelimiters)*2)
	for _, delimiter := range orderedDelimiters {
		replacements = append(replacements, delimiter, ",")
	}
	return strings.Split(strings.NewReplacer(replacements...).Replace(numbers), ",")
}
