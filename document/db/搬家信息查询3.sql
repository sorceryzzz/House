SELECT mvhInfo.f_Bj_ID,mvhInfo.f_Bj_UID,mvhInfo.f_IsDiplaySex,mvhInfo.f_IsDiplaySex,mvhInfo.f_IsNeedHelpBj,f_BjCostsStart,
                                    mvhInfo.f_BjCostEnd, mvhInfo.f_BjDecription,mvhInfo.f_InsertTime,mvhInfo.f_UpdateTime
                             FROM `movehouse`.`movehouseinfo` AS mvhInfo WHERE mvhInfo.f_Bj_UID='000000000000000000'  AND (mvhInfo.f_bj_id >=(
                                    SELECT MAX(mvhInfo.f_bj_id) FROM (
                                        SELECT mvhA.f_bj_id FROM `movehouse`.`movehouseinfo` AS mvhA ORDER BY mvhA.f_bj_id LIMIT 1,1) AS tmp
                                    ) )
                             ORDER BY mvhInfo.f_bj_id ASC      
                             LIMIT 10;
   SELECT COUNT(mvhInfo.f_Bj_ID)
                                  FROM `movehouse`.`movehouseinfo` AS mvhInfo