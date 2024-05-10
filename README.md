# Description

I created a chess program that adheres to official chess rules, ensuring players can't make any invalid moves. To achieve this, I implemented a series of checks for every move a player attempts:

1. **Board Setup**: The game begins with the standard chessboard layout, with pieces positioned according to traditional chess rules.

2. **Move Validation**: Before a move is executed, the program verifies its legality based on the type of piece, the current board state, and chess rules. For example:
   - **Pawns**: They can only move forward, with special rules for captures and en passant.
   - **Rooks, Bishops, and Queens**: They can move along straight lines, but cannot jump over other pieces.
   - **Knights**: They have a unique L-shaped movement, able to jump over other pieces.
   - **Kings**: They can move one square in any direction, with special checks for castling.

3. **Check and Checkmate**: The program checks if a move would leave the king in check, which is invalid. It also verifies checkmate conditions, ending the game when applicable.

4. **Turn Management**: The program alternates turns between the players and tracks the overall game state, including checks, captures, and castling rights.

5. **Error Handling**: If a player attempts an invalid move, the program provides feedback, explaining why the move isn't allowed.

Overall, this chess program offers a robust playing experience, adhering to chess rules and ensuring a fair game. By implementing thorough validation and logic, players can focus on strategy without worrying about accidental rule violations.
