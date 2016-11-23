func <- function(sensor_value, mean_pass, sd_pass, mean_fail, sd_fail)
{
  pdf_pass <- dnorm(sensor_value, mean_, sd)
  pdf_fail <- dnorm(sensor_value, mean, sd)
}

test <- func(0, 0, 1)
test