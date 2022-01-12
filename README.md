# TwoPoints

Task:

The application should draw lines between two points selected by the user. The lines must be continuous, but not necessarily straight. The lines may not cross any lines previously drawn.

Examples:

-> User clicks at two points

-> A continuous line is drawn between the two points

-> User clicks at two new points

-> A new continuous line is drawn which does not cross the previous line(s)

-> And so on for any number of lines…

We will review the design, naming, comments, code structure, and algorithm.

Please note that you may not copy and paste code from the Internet into your solution. You must write the code yourself. If you learn about specific parts of solving the problem from the Internet you must include the source (with an URL to the source and explain what you used as a comment in the code).

Solution:

I used the Breadth-First Search algorithm and incidence lists to solve the problem. 
Steps:

-> defined canvas as a non-directed graph -> every pixel is a node and every node has neighbours (pixels) 

-> put all pixels to incidence lists where index is a pixel id and value is a collection of neighbours

-> run BFS algorithm with incidence lists for selected pixels (user cliked two times on canvas)

-> draw line -> pixels chosen during BFS algorithm run 

-> remove used pixels from collection of pixels  

To see more details check comments in classes. The code is mine, I didn't copy anything.   

PS
I set a 3px width to draw a line on the canvas (it looks better then 1px IMO) so sometimes when the lines are very close it seems like one is on top of the other but logically it's okay I think;)
