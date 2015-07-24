SELECT
  `f_Bj_ID`,
  `f_Bj_UID`,
  `f_IsDiplaySex`,
  `f_IsNeedHelpBj`,
  `f_BjCostsStart`,
  `f_BjCostEnd`,
  `f_BjDecription`,
  `f_InsertTime`,
  `f_UpdateTime`,
  `avg1`,
  `avg2`
FROM `movehouse`.`movehouseinfo`
LIMIT 0, 1000;