import pygame, random

pygame.init()
window = (width, height) = 600, 300
display = pygame.display.set_mode(window)
cell_size = 5
cols, rows = int(display.get_width()/cell_size), int(display.get_height()/cell_size)

COLOUR_BLACK = (0,0,0)
COLOUR_GREY = (20,20,20)
COLOUR_CELL = (100,70,30)

def make_new_grid(rows, cols, init = False):
    if init:
        return [[random.randint(0, 1) for _ in range(cols)] for _ in range (rows)]

    new_grid = [[0 for _ in range(cols)] for _ in range(rows)]
    for row in range(cols):
        for col in range(rows):
            neighbors = count_neighbours(grid, col, row)

            if grid[col][row] == 0 and neighbors == 3 :
                new_grid[col][row] = 1

            elif grid[col][row] == 1 and (neighbors < 2 or neighbors > 3):
                new_grid[col][row] = 0

            else:
                new_grid[col][row] = grid[col][row]

    return new_grid

def draw_grid(grid, cell_size):
    for col in range(cols):
        for row in range(rows):
            x = col * cell_size
            y = row * cell_size
            if grid[row][col] == 1:
                pygame.draw.rect(display, COLOUR_CELL, (x, y, cell_size, cell_size))
            else:
                pygame.draw.rect(display, COLOUR_BLACK, (x, y, cell_size, cell_size))

            pygame.draw.line(display, COLOUR_GREY, (x, y), (x, height))
            pygame.draw.line(display, COLOUR_GREY, (x, y), (width, y))


def count_neighbours(grid, x, y):
    count = 0
    for i in range(-1, 2):
        for j in range(-1, 2):
            col = (y + j + cols) % cols
            row = (x + i + rows) % rows

            count += grid[row][col]
    count -= grid[x][y]
    return count

grid = make_new_grid(rows, cols, init=True)
while True:
    for event in pygame.event.get():
        if event.type ==pygame.KEYDOWN and event.key == pygame.K_ESCAPE:
            pygame.quit()
   
    draw_grid(grid, cell_size)
    grid = make_new_grid(rows, cols)

    pygame.display.update()
