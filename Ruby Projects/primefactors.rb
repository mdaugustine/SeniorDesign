puts 'Enter an integer to calculate the factors'
x = gets.chomp.to_i

def primeFactors(number)
	for i in 2..number
		while number % i == 0
			number = number/i
			puts i
		end
	end
end

primeFactors(x)

gets.chomp