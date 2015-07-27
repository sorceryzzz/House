--发布搬家信息
INSERT INTO `movehouse`.`movehouseinfo`
            (`f_Bj_ID`,
             `f_Bj_UID`,
             `f_IsDiplaySex`,
             `f_IsNeedHelpBj`,
             `f_BjCostsStart`,
             `f_BjCostEnd`,
             `f_BjDecription`,
             `f_InsertTime`,
             `f_UpdateTime`,
             `avg1`,
             `avg2`)
VALUES (@f_Bj_ID,
        @f_Bj_UID,
        @f_IsDiplaySex,
        @f_IsNeedHelpBj,
        @f_BjCostsStart,
        @f_BjCostEnd,
        @f_BjDecription,
        @f_InsertTime,
        @f_UpdateTime,
        @avg1,
        @avg2);
        
 --浏览搬家信息     
SELECT mvhInfo.f_Bj_ID,mvhInfo.f_Bj_UID,mvhInfo.f_IsDiplaySex,mvhInfo.f_IsDiplaySex,mvhInfo.f_IsNeedHelpBj,f_BjCostsStart,
mvhInfo.f_BjCostEnd, mvhInfo.f_BjDecription,mvhInfo.f_InsertTime,mvhInfo.f_UpdateTime
FROM `movehouse`.`movehouseinfo` AS mvhInfo 
WHERE  (mvhInfo.f_id >=(
       SELECT MAX(mvhInfo.f_id) FROM (
           SELECT mvhA.f_id FROM `movehouse`.`movehouseinfo` AS mvhA ORDER BY mvhA.f_id LIMIT 1,1) AS tmp
       ) )
ORDER BY mvhInfo.f_id ASC      
LIMIT 10;
 
 --搬家信息总数
SELECT COUNT(mvhInfo.f_Bj_ID)
FROM `movehouse`.`movehouseinfo` AS mvhInfo
 
 
 --搬家专人插入
 INSERT INTO `movehouse`.`movehousepersoninfo`
            (`f_Bjp_ID`,
             `f_Bjp_UID`,
             `f_BjpCarTypeID`,
             `f_BjpCostStart`,
             `f_BjpCostEnd`,
             `f_InsertTime`,
             `f_UpdateTime`,
             `avg1`,
             `avg2`)
VALUES ('f_Bjp_ID',
        'f_Bjp_UID',
        'f_BjpCarTypeID',
        'f_BjpCostStart',
        'f_BjpCostEnd',
        'f_InsertTime',
        'f_UpdateTime',
        'avg1',
        'avg2');
 
 --查询搬家专人信息
 SELECT
  `f_Bjp_ID`,
  `f_Bjp_UID`,
  `f_BjpCarTypeID`,
  `f_BjpCostStart`,
  `f_BjpCostEnd`,
  `f_BjpDecription`,
  `f_InsertTime`,
  `f_UpdateTime`,
  `avg1`,
  `avg2`
FROM `movehouse`.`mvhspcinfo` AS mvhspc
WHERE
 (MvhSpc.f_Bjp_ID >=(
                      SELECT MAX(MvhSpc.f_Bjp_ID) FROM (
                                        SELECT mvhspcA.f_Bjp_ID FROM `movehouse`.`mvhspcinfo` AS mvhspcA ORDER BY mvhspcA.f_Bjp_ID LIMIT 0,1) AS tmp
                                    ) )
                             ORDER BY mvhspc.f_Bjp_ID ASC      
                             LIMIT 10;
                             
 --查询搬家专人信息总数
 SELECT COUNT(mvhspc.f_Bjp_ID)
FROM `movehouse`.`movehousepersoninfo` AS mvhspc
 
 