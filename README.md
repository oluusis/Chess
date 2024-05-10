# Description

I created a chess program that adheres to official chess rules, ensuring players can't make any invalid moves. To achieve this, I implemented a series of checks for every move a player attempts:

1. **Board Setup**: The game begins with the standard chessboard layout, with pieces positioned according to traditional chess rules.

2. **Move Validation**: Before a move is executed, the program verifies its legality based on the type of piece, the current board state, and chess rules. For example:
   - **Pawns**: They can only move forward, with special rules for captures and en passant.
   - **Rooks, Bishops, and Queens**: They can move along straight lines, but cannot jump over other pieces.
   - **Knights**: They have a unique L-shaped movement, able to jump over other pieces.
   - **Kings**: They can move one square in any direction, with special checks for castling.

3. **Turn Management**: The program alternates turns between the players and tracks the overall game state, including checks, captures, and castling rights.

4. **Error Handling**: If a player attempts an invalid move, the program don't make a move.

Overall, this chess program offers a robust playing experience, adhering to chess rules and ensuring a fair game. By implementing thorough validation and logic, players can focus on strategy without worrying about accidental rule violations.
<tr></tr>

![image](https://github.com/oluusis/Chess/assets/90570377/7dd07658-f611-4055-9527-1d8f55faf697)

