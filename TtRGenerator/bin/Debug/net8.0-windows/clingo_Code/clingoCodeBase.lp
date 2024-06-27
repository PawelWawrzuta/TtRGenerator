


{in(X,Y)} :- e(X,Y).
:- in(X1,Y1), in(X2,Y2), cross(X1,Y1,X2,Y2).
:- v(X), not in(X,_).
:- v(Y), not in(_,Y).


reachable(X, Y) :- in(X, Y).
reachable(X, Y) :- in(Y, X).
reachable(X, Z) :- reachable(X, Y), in(Y, Z).
reachable(X, Z) :- reachable(X, Y), in(Z, Y).

:- v(X), v(Y), X != Y, not reachable(X, Y).

#maximize{1, X, Y: in(X,Y)}.
#show in/2.