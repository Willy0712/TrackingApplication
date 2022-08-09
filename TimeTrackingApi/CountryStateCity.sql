SELECT * from Country
  SELECT * from [State]
  SELECT * from [City]
    SELECT * from [Tracking]
    

  -- Update rows in table 'TableName'
  UPDATE Tracking
  SET
    [Countryid] = 1,
    [Stateid] = 1,
    [Cityid] = 1
    -- add more columns and values here
  WHERE id in (3, 5, 10005)	/* add search conditions here */
  GO  
  -- Insert rows into table 'TableName'
  INSERT INTO Country
  ( -- columns to insert data into
   [Name], [CODE]
  )
  VALUES
  ( -- first row: values for the columns in the list above
   'Romania', 'RO'
  ),
  ( -- first row: values for the columns in the list above
   'Bulgaria', 'BG'
  ),
  ( -- first row: values for the columns in the list above
   'Germania', 'GE'
  )



  -- Insert rows into table 'TableName'
  INSERT INTO State
  ( -- columns to insert data into
   [Name], [CODE], [Countryid]
  )
  VALUES
  ( -- first row: values for the columns in the list above
   'Cluj', 'CJ', 1
  ),
  ( -- first row: values for the columns in the list above
   'Mures', 'MS', 1
  ),
  ( -- first row: values for the columns in the list above
   'Pernik', 'PR', 2
  ), 
  ( -- first row: values for the columns in the list above
   'Plovdiv', 'PR', 2
  ),
  ( -- first row: values for the columns in the list above
   'Bayern', 'B', 3
  ), 
  ( -- first row: values for the columns in the list above
   'Baden-Wurtemberg', 'PR', 3
  )


   INSERT INTO City
  ( -- columns to insert data into
   [Name], [CODE]
  )
  VALUES
  ( -- first row: values for the columns in the list above
   'Cluj-Napoca', 'CJ', 1
  ),
  ( -- first row: values for the columns in the list above
   'Targu-Mures', 'MS', 1
  ),
  ( -- first row: values for the columns in the list above
   'PernikPernika', 'PR', 2
  ), 
  ( -- first row: values for the columns in the list above
   'PlovdivPlovdiv', 'PR', 2
  ),
  ( -- first row: values for the columns in the list above
   'Bayern-Munchen', 'B', 3
  ), 
  ( -- first row: values for the columns in the list above
   'Ulm', 'PR', 3
  )
  
  

  