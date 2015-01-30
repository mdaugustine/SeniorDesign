x = 0
y = 0
heading = 0
obstacles = [[-5, 3],[4, 6],[2,9],[-9,1],[8,-6],[4,-3],[-10,-5],[-7,8],[9,-2],[-4,1]]

def plotGrid(x,y, obstacles)
	for i in -10..10
		for j in -10..10
			if obstacles.detect { |x, y| x == j && y == (i*-1) }
				print 'x'
			else
				if (i*-1) == y && j == x
					print '@'
				else
					print '-'
				end
			end
		end
		print "\n"
	end
end

def TurnRight(heading)
	if heading < 3
		heading = heading + 1
	else
		heading = 0
	end
end

def TurnLeft(heading)
	if heading > 0
		heading = heading - 1
	else
		heading = 3
	end
end

def Forward(heading, x, y, obstacles)

	case heading
		when 0
			y = y + 1
		when 1
			x = x + 1
		when 2
			y = y - 1
		when 3
			x = x - 1
	end
	
	if obstacles.detect { |n, m| n == x && m == y }
		puts "Obstacle!"
		case heading
			when 0
				y = y - 1
			when 1
				x = x - 1
			when 2
				y = y + 1
			when 3
				x = x + 1
		end
	end
	return x, y
end

def Back(heading, x, y, obstacles)
	case heading
		when 0
			y = y - 1
		when 1
			x = x - 1
		when 2
			y = y + 1
		when 3
			x = x + 1
	end
	
	if obstacles.detect { |n, m| n == x && m == y }
		puts "Obstacle!"
		case heading
			when 0
				y = y + 1
			when 1
				x = x + 1
			when 2
				y = y - 1
			when 3
				x = x - 1
		end
	end
	
	return x, y
end

def getHeadingString(heading)
	case heading
		when 0
			"North"
		when 1
			"East"
		when 2
			"South"
		when 3
			"West"
	end
end
		

instruction = "x"

while instruction != "e"

	puts "Heading #{getHeadingString(heading)}"
	puts "Location #{x}, #{y}"
	plotGrid(x,y, obstacles)
	
	instructions = gets.chomp
	
	instructions.each_char do |instruction|
		case instruction
			when "f"
				x,y = Forward(heading, x, y, obstacles)
			when "b"
				x,y = Back(heading, x, y, obstacles)
			when "l"
				heading = TurnLeft(heading)
			when "r"
				heading = TurnRight(heading)
			when "e"
				exit
		end
		
		if x > 10
			x = x -21
		end
		if x < -10
			x = x + 21
		end
		if y > 10
			y = y - 21
		end
		if y < -10
			y = y + 21
		end
	end
		
end
