using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PersonnelDepartmentApp.Models;
using PersonnelDepartmentApp.Services;
using System.Collections.Generic;

public class PositionService
{
    private List<Position> positions = new List<Position>();
    private FileService fileService = new FileService();

    public List<Position> GetPositions()
    {
        // Реализуйте загрузку из файла или базы
        return positions;
    }

    public void AddPosition(Position position)
    {
        position.Id = GetNextPositionId();
        positions.Add(position);
        SavePositions();
    }

    public void EditPosition(int id, Position updatedPosition)
    {
        var pos = positions.FirstOrDefault(p => p.Id == id);
        if (pos != null)
        {
            pos.Title = updatedPosition.Title;
            pos.Salary = updatedPosition.Salary;
            pos.Requirements = updatedPosition.Requirements;
            SavePositions();
        }
    }

    public void DeletePosition(int id)
    {
        var pos = positions.FirstOrDefault(p => p.Id == id);
        if (pos != null)
        {
            positions.Remove(pos);
            SavePositions();
        }
    }

    public void SavePositions()
    {
        fileService.SavePositionsToExcel(positions);
    }

    public void ReloadPositions()
    {
        positions = fileService.LoadPositionsFromExcel();
    }

    public int GetNextPositionId()
    {
        return positions.Count > 0 ? positions.Max(p => p.Id) + 1 : 1;
    }
}
