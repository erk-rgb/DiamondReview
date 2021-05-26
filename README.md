# DiamondReview
Review

Create the View first


CREATE VIEW [dbo].[DiamondView]
AS
SELECT     ROW_NUMBER() OVER (ORDER BY i.Name ASC) AS RowNr, ISNULL
    ((SELECT     TOP (1) ph.Id
        FROM         dbo.ItemPhotos AS ph INNER JOIN
                              dbo.Items AS i2 ON i2.Id = ph.ItemId INNER JOIN
                              dbo.Types AS t2 ON t2.Id = ph.TypeId INNER JOIN
                              dbo.ItemPhotoPropertySet AS m2 ON m2.ItemPhotoId = ph.Id AND m2.PropertyId = 1 INNER JOIN
                              dbo.ItemPhotoPropertySet AS s2 ON s2.ItemPhotoId = ph.Id AND s2.PropertyId = 2
        WHERE     (ph.TypeId = 1) AND (m2.Value = m.Value) AND (s2.Value = s.Value) AND (ph.ItemId = i.Id) AND (ph.IsActive = 1)), 0) AS Id,
    (SELECT     TOP (1) ph.FileName
      FROM          dbo.ItemPhotos AS ph INNER JOIN
                             dbo.Items AS i2 ON i2.Id = ph.ItemId INNER JOIN
                             dbo.Types AS t2 ON t2.Id = ph.TypeId INNER JOIN
                             dbo.ItemPhotoPropertySet AS m2 ON m2.ItemPhotoId = ph.Id AND m2.PropertyId = 1 INNER JOIN
                             dbo.ItemPhotoPropertySet AS s2 ON s2.ItemPhotoId = ph.Id AND s2.PropertyId = 2
      WHERE      (ph.TypeId = 1) AND (m2.Value = m.Value) AND (s2.Value = s.Value) AND (ph.ItemId = i.Id) AND (ph.IsActive = 1)) AS FileName, 'Photo' AS Type, 1 AS TypeId, 
i.Name AS ItemType, i.Id AS ItemTypeId, 1 AS MetalPropertyId, m.Value AS MetalValue, 2 AS ShapePropertyId, s.Value AS ShapeValue,
    (SELECT     TOP (1) ph.Position
      FROM          dbo.ItemPhotos AS ph INNER JOIN
                             dbo.Items AS i2 ON i2.Id = ph.ItemId INNER JOIN
                             dbo.Types AS t2 ON t2.Id = ph.TypeId INNER JOIN
                             dbo.ItemPhotoPropertySet AS m2 ON m2.ItemPhotoId = ph.Id AND m2.PropertyId = 1 INNER JOIN
                             dbo.ItemPhotoPropertySet AS s2 ON s2.ItemPhotoId = ph.Id AND s2.PropertyId = 2
      WHERE      (ph.TypeId = 1) AND (m2.Value = m.Value) AND (s2.Value = s.Value) AND (ph.ItemId = i.Id) AND (ph.IsActive = 1)) AS Position,
    (SELECT     TOP (1) ph.Id
      FROM          dbo.ItemPhotos AS ph INNER JOIN
                             dbo.Items AS i2 ON i2.Id = ph.ItemId INNER JOIN
                             dbo.Types AS t2 ON t2.Id = ph.TypeId INNER JOIN
                             dbo.ItemPhotoPropertySet AS m2 ON m2.ItemPhotoId = ph.Id AND m2.PropertyId = 1 INNER JOIN
                             dbo.ItemPhotoPropertySet AS s2 ON s2.ItemPhotoId = ph.Id AND s2.PropertyId = 2
      WHERE      (ph.TypeId = 2) AND (m2.Value = m.Value) AND (s2.Value = s.Value) AND (ph.ItemId = i.Id) AND (ph.IsActive = 1)) AS ThumbId,
    (SELECT     TOP (1) ph.FileName
      FROM          dbo.ItemPhotos AS ph INNER JOIN
                             dbo.Items AS i2 ON i2.Id = ph.ItemId INNER JOIN
                             dbo.Types AS t2 ON t2.Id = ph.TypeId INNER JOIN
                             dbo.ItemPhotoPropertySet AS m2 ON m2.ItemPhotoId = ph.Id AND m2.PropertyId = 1 INNER JOIN
                             dbo.ItemPhotoPropertySet AS s2 ON s2.ItemPhotoId = ph.Id AND s2.PropertyId = 2
      WHERE      (ph.TypeId = 2) AND (m2.Value = m.Value) AND (s2.Value = s.Value) AND (ph.ItemId = i.Id) AND (ph.IsActive = 1)) AS Thumb
FROM         dbo.Items AS i INNER JOIN
                      dbo.ItemPhotos AS ip ON i.Id = ip.ItemId INNER JOIN
                      dbo.ItemPhotoPropertySet AS m ON m.ItemPhotoId = ip.Id AND m.PropertyId = 1 INNER JOIN
                      dbo.ItemPhotoPropertySet AS s ON s.ItemPhotoId = ip.Id AND s.PropertyId = 2
GROUP BY m.Value, s.Value, i.Id, i.Name

GO
