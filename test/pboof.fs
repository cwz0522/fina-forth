require pboof.fs
require test/tester.fs
\ : { ;
\ : } 2drop ;
\ : -> ;

osize value lastosize
: increased osize lastosize over to lastosize - ;

world extend

{ osize -> 9 cells }
{ increased -> 0 cells }

object clone v2
{ increased -> 2 cells }
v2 extend  
1 cells member x  x off
1 cells member y  y off
extended
{ increased -> 2 cells }

v2 clone v3

{ increased -> 4 cells } 
v3  extend
1 cells member z  z off
extended
{ increased -> 1 cells }

object clone rect 
{ increased -> 2 cells }
rect extend
v2 instance pos
v2 instance dim

100 dim x !  200 dim y !
extended

{ increased -> 8 cells }

object clone window
{ increased -> 2 cells }
window extend
rect instance inner  300 inner dim x !  11 inner pos x ! 
rect instance outer  400 outer dim y !  12 outer pos x ! 
extended
{ increased -> 20 cells }

{ rect pos x  window inner pos x = -> false }

window clone window2
window2 extend
1 cells member xxx  123 xxx !
rect instance yyy
1 inner pos x !
2 inner pos y !
3 inner dim x !
4 inner dim y !
10 outer pos x !
20 outer pos y !
30 outer dim x !
40 outer dim y !
100 yyy pos x !
200 yyy pos y !
300 yyy dim x !
400 yyy dim y !
extended
cr window2 print cr

: .window ( obj -- )
   as window print ;

window2 self .window
: t window2 inner pos print .ctx window2 print ;
t
.ctx

object clone reftest 
reftest extend
window reference w
w print
: test w print ;
test
extended

extended
