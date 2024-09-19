using MyClassLibrary.Essentials;
using System.ComponentModel;

namespace ex_BindingToA2dArray_context;

public class Matrix2d : INotifyPropertyChanged
{

    public Matrix2d(Plateau board)
    {
        matrix = board.Cases;
        board.CaseChanged += Board_CaseChanged;
    }

    private void Board_CaseChanged(object? sender, MyClassLibrary.Events.CaseChangedEventArgs e)
    {
        Matrix[e.XDest, e.YDest].IsOccuped = true;
        Matrix[e.XDest, e.YDest].Inhabitant = Matrix[e.X, e.Y].Inhabitant;

        Matrix[e.X, e.Y].IsOccuped = false;
        Matrix[e.X, e.Y].Inhabitant = null;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public int NbRows => matrix?.GetLength(1) ?? 0;
    public int NbColumns => matrix?.GetLength(0) ?? 0;

    public Case[,] Matrix
    {
        get
        {
            if (matrix == null) return new Case[,] { { } };
            
            Case[,] mat = new Case[NbColumns, NbRows];
            for (int numRow = 0; numRow < matrix.GetLength(1); numRow++)
            {
                for (int numCol = 0; numCol < matrix.GetLength(0); numCol++)
                {
                    mat[numCol, numRow] = matrix[numCol, numRow];
                }
            }
            return matrix;
        }
        set
        {
            if (value == null) return;
            if (value == matrix) return;

            matrix = value;
            OnPropertyChanged(nameof(Matrix));
        }
    }
    private Case[,]? matrix;


    public IEnumerable<Case> FlatMatrix2d
    {
        
        get
        {
            List<Case> flatMatrix = new();

            if (matrix == null) return flatMatrix;

            for (int numRow = 0; numRow < matrix.GetLength(1); numRow++)
            {
                for (int numCol = 0; numCol < matrix.GetLength(0); numCol++) 
                {
                    flatMatrix.Add(matrix[numCol, numRow]);
                }
            }
            return flatMatrix;
        }
        
    }
}

