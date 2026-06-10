import { ReactNode } from "react";
import { Box, LinearProgress, Typography } from "@mui/material";
import DataUsageRoundedIcon from "@mui/icons-material/DataUsageRounded";
import CompressRoundedIcon from "@mui/icons-material/CompressRounded";
import TrendingDownRoundedIcon from "@mui/icons-material/TrendingDownRounded";
import { SizeStatsProps } from "../../Interfaces/Encode/SizeStatsProps";

interface StatCardProps {
  icon: ReactNode;
  label: string;
  value: string;
  color: string;
  delay?: number;
}

const StatCard = ({ icon, label, value, color, delay = 0 }: StatCardProps) => (
  <Box sx={{
    flex: 1,
    background: 'rgba(6,11,22,0.7)',
    border: `1px solid ${color}33`,
    borderRadius: 2,
    p: 2,
    display: 'flex',
    flexDirection: 'column',
    gap: 0.5,
    animation: `cardIn 0.4s cubic-bezier(0.4,0,0.2,1) ${delay}s both`,
    '@keyframes cardIn': {
      from: { opacity: 0, transform: 'translateY(12px)' },
      to:   { opacity: 1, transform: 'translateY(0)' },
    },
    transition: 'border-color 0.2s ease',
    '&:hover': { borderColor: `${color}66` },
  }}>
    <Box sx={{ color, display: 'flex', alignItems: 'center', gap: 0.75, fontSize: '0.72rem', fontFamily: 'var(--font-ui)', fontWeight: 500, letterSpacing: '0.5px', textTransform: 'uppercase', opacity: 0.8 }}>
      {icon}
      {label}
    </Box>
    <Typography sx={{ color: '#E2E8F0', fontFamily: 'var(--font-code)', fontSize: '1.15rem', fontWeight: 700, letterSpacing: '1px' }}>
      {value}
    </Typography>
  </Box>
);

const SizeStats = ({ originalSize, encodedSize }: SizeStatsProps) => {
  if (originalSize <= 0) return null;

  const gainPct = ((1 - encodedSize / originalSize) * 100);
  const gainStr = gainPct.toFixed(2);
  const progressVal = Math.max(0, Math.min(100, gainPct));
  const gainColor = gainPct >= 40 ? '#34D399' : gainPct >= 20 ? '#F59E0B' : '#F87171';

  return (
    <Box sx={{ mb: 2, animation: 'cardIn 0.35s ease both', '@keyframes cardIn': { from: { opacity: 0 }, to: { opacity: 1 } } }}>
      <Box sx={{ display: 'flex', gap: 1.5, mb: 1.5, flexWrap: 'wrap' }}>
        <StatCard
          icon={<DataUsageRoundedIcon sx={{ fontSize: 14 }} />}
          label="Original"
          value={`${originalSize} bits`}
          color="#94A3B8"
          delay={0}
        />
        <StatCard
          icon={<CompressRoundedIcon sx={{ fontSize: 14 }} />}
          label="Encodé"
          value={`${encodedSize} bits`}
          color="#00D4FF"
          delay={0.08}
        />
        <StatCard
          icon={<TrendingDownRoundedIcon sx={{ fontSize: 14 }} />}
          label="Gain"
          value={`${gainStr}%`}
          color={gainColor}
          delay={0.16}
        />
      </Box>
      <Box sx={{ px: 0.5 }}>
        <LinearProgress
          variant="determinate"
          value={progressVal}
          sx={{ '& .MuiLinearProgress-bar': { background: `linear-gradient(90deg, #00D4FF, ${gainColor})` } }}
        />
      </Box>
    </Box>
  );
};
export default SizeStats;
